import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { AgmCoreModule } from '@agm/core';
import * as hljs from 'highlight.js';
import { HighlightJsModule, HIGHLIGHT_JS } from 'angular-highlight-js';
import * as hljsTypescript from 'highlight.js/lib/languages/typescript';
 import { Routes, RouterModule } from '@angular/router';
import { ProblemNotificationService } from '../service/problem-notification/problem-notification.service';
import { GreenFieldsComponent, DialogOverviewExampleDialog } from './green-fields.component';
import { GreenFieldsService } from '../service/green-fields/green-fields.service';
import { MatDialogModule, MatListModule } from "@angular/material";
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatExpansionModule } from '@angular/material/expansion';
export const appRoutes: Routes = [
  { path: '', component: GreenFieldsComponent, data: { animation: 'googlemap' } },

]

export function highlightJsFactory(): any {
  hljs.registerLanguage('typescript', hljsTypescript);
  return hljs;
}

@NgModule({
  imports: [
    CommonModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    HttpClientModule,
    MatListModule,
    MatExpansionModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAXTJwhYqJ6Pc7VXGRMTv40N1WRLqzuSNs'
    }),
    HighlightJsModule.forRoot({
      provide: HIGHLIGHT_JS,
      useFactory: highlightJsFactory
    }),
    RouterModule.forChild(appRoutes)

  ],

  declarations: [
    GreenFieldsComponent, DialogOverviewExampleDialog],

  exports: [
  ],
  entryComponents: [
    DialogOverviewExampleDialog
  ],
  providers: [
    { provide: 'problemNotificationService', useClass: ProblemNotificationService },
    { provide: 'greenFieldsService', useClass: GreenFieldsService }

  ]

})


export class GreenFieldsModule { }
