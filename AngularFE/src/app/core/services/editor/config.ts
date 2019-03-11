import {Injectable} from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';
@Injectable()
export class EditorConfigService {
  public getConfig() : AngularEditorConfig
  {
      return {
        editable: true,
        spellcheck: true,
        height: '35rem',
        minHeight: '5rem',
        translate: 'no',
        uploadUrl: 'editor-image-upload'
    }
  }
}
