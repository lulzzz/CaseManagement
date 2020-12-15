var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { MonacoEditorModule } from 'ngx-monaco-editor';
import { MaterialModule } from '../../shared/material.module';
import { SharedModule } from '../../shared/shared.module';
import { CmmnPlansRoutes } from './cmmninstances.routes';
import { ViewCmmnPlanInstanceComponent } from './view/view.component';
import { ViewCasePlanEltInstanceComponent } from './view/viewelt.component';
import { ViewTransitionHistoriesComponent } from './view/viewtransitionhistories.component';
var CmmnInstancesModule = (function () {
    function CmmnInstancesModule() {
    }
    CmmnInstancesModule = __decorate([
        NgModule({
            imports: [
                CommonModule,
                NgxChartsModule,
                MonacoEditorModule.forRoot(),
                FormsModule,
                HttpClientModule,
                CmmnPlansRoutes,
                MaterialModule,
                SharedModule
            ],
            entryComponents: [],
            declarations: [
                ViewCmmnPlanInstanceComponent,
                ViewCasePlanEltInstanceComponent,
                ViewTransitionHistoriesComponent
            ],
            exports: []
        })
    ], CmmnInstancesModule);
    return CmmnInstancesModule;
}());
export { CmmnInstancesModule };
//# sourceMappingURL=cmmninstances.module.js.map