import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { MonacoEditorModule } from 'ngx-monaco-editor';
import { MaterialModule } from '../../shared/material.module';
import { SharedModule } from '../../shared/shared.module';
import { BpmnFilesRoutes } from './bpmnfiles.routes';
import { ListBpmnFilesComponent } from './list/list.component';
import { ViewBpmnFileInformationComponent } from './view/information/information.component';
import { ListBpmnInstancesComponent } from './view/instances/instances.component';
import { ViewBpmnFileUIEditorComponent } from './view/uieditor/uieditor.component';
import { ViewBpmnFileComponent } from './view/view.component';
import { ViewBpmnFileXMLEditorComponent } from './view/xmleditor/xmleditor.component';

@NgModule({
    imports: [
        CommonModule,
        NgxChartsModule,
        MonacoEditorModule.forRoot(),
        FormsModule,
        HttpClientModule,
        BpmnFilesRoutes,
        MaterialModule,
        SharedModule
    ],
    entryComponents: [ ],
    declarations: [ListBpmnFilesComponent, ViewBpmnFileComponent, ViewBpmnFileInformationComponent, ViewBpmnFileXMLEditorComponent, ViewBpmnFileUIEditorComponent, ListBpmnInstancesComponent],
    exports: [ ListBpmnFilesComponent  ]
})

export class BpmnFilesModule { }