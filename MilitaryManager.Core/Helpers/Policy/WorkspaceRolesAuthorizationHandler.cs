using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Entities.UnitUserEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MilitaryManager.Core.Helpers.Policy
{
    public class WorkspaceRolesAuthorizationHandler : AuthorizationHandler<WorkspaceRolesRequirement>
    {
        private readonly IRepository<Unit, int> _unitRepository;
        private readonly IRepository<UnitUser, int> _unitUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkspaceRolesAuthorizationHandler(IRepository<Unit, int> unitRepository, IRepository<UnitUser, int> unitUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _unitRepository = unitRepository;
            _unitUserRepository = unitUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, WorkspaceRolesRequirement requirement)
        {
            var request = _httpContextAccessor.HttpContext.Request;

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var comander = (await _unitUserRepository.GetFirstBySpecAsync(new UnitUsers.UnitUserByUserId(userId))).Unit;

            int? divisionId = null;

            if (request.RouteValues.TryGetValue("id", out object obj) &&
                int.TryParse(obj.ToString(), out int id))
            {
                var unit = await _unitRepository.GetByKeyAsync(id);
                divisionId = unit.DivisionId;
            }

            if (!divisionId.HasValue)
            {
                var syncIoFeature = _httpContextAccessor.HttpContext.Features.Get<IHttpBodyControlFeature>();
                syncIoFeature.AllowSynchronousIO = true;

                using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
                {
                    var bodyStr = String.Empty;
                    bodyStr = reader.ReadToEnd();
                    JObject jObj = JObject.Parse(bodyStr);
                    divisionId = (int?)jObj["divisionId"];
                }
            }

            if (divisionId.HasValue && comander != null && divisionId == comander.DivisionId)
            {
                context.Succeed(requirement);
            }

            new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }
    }
}
