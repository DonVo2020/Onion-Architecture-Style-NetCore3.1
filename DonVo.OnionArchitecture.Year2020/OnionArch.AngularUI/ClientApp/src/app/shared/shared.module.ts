import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FooterFormComponent } from '../shared/footer-form/footer-form.component';
import { MessageErrorComponent } from '../shared/message-error/message-error.component';
import { ConfirmDeleteComponent } from '../shared/confirm-delete/confirm-delete.component';
import { MaterialsModule } from './materials.module';
import { DialogService } from './services/dialog.service';
import { AlertService } from './services/alert.service';

@NgModule({
  declarations: [
    MessageErrorComponent,
    ConfirmDeleteComponent,
    FooterFormComponent,
  ],
  imports: [
    CommonModule,
    MaterialsModule,
  ],
  exports: [
    MessageErrorComponent,
    FooterFormComponent,
    ConfirmDeleteComponent,
  ],
  providers: [DialogService, AlertService],
  entryComponents: [ConfirmDeleteComponent],
})
export class SharedModule {}
