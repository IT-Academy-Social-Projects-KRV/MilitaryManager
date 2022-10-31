using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.TemplatePlaceholderEntity
{
    public class TemplatePlaceholders
    {
        internal class TemplatePlaceholdersByTemplateId : Specification<TemplatePlaceholder>
        {
            public TemplatePlaceholdersByTemplateId(int templateId)
            {
                Query.Where(x => x.TemplateId == templateId);
            }
        }
    }
}
