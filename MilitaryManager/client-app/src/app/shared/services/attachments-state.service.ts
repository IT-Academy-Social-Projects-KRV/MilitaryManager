import { Injectable } from '@angular/core';
import { StateService } from '../../shared/state.service';
import { Observable} from 'rxjs';
import {shareReplay } from 'rxjs/operators';
import { AttachmentModel } from '../models/attachment.model';
import { AttachmentsService } from './api/attachment.service';

interface AttachmentState {
  attachments: AttachmentModel[];
}

const initialState: AttachmentState = {
  attachments: []
}

@Injectable({
  providedIn: 'root'
})
export class AttachmentStateService extends StateService<AttachmentState>{

  attachments$: Observable<AttachmentModel[]>= this.select(state => state.attachments).pipe(
    shareReplay({refCount: true, bufferSize: 1}))

  constructor(private apiService: AttachmentsService) {
    super(initialState);
  }
  
}
