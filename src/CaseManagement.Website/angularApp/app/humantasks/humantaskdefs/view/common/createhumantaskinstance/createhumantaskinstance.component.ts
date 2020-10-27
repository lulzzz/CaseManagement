﻿import { Component, ViewEncapsulation, Input } from '@angular/core';
import { HumanTaskDef } from '@app/stores/humantaskdefs/models/humantaskdef.model';
import { CreateHumanTaskInstance } from '@app/stores/humantaskinstances/parameters/create-humantaskinstance.model';
import { Parameter } from '@app/stores/common/operation.model';

@Component({
    selector: 'createhumantaskinstance-component',
    templateUrl: './createhumantaskinstance.component.html',
    encapsulation: ViewEncapsulation.None
})
export class CreateHumanTaskInstanceComponent {
    private _humanTaskDef: HumanTaskDef;
    private _createHumanTaskInstance: CreateHumanTaskInstance;
    @Input()
    get humanTaskDef() {
        return this._humanTaskDef;
    }
    set humanTaskDef(v: HumanTaskDef) {
        if (!v) {
            return;
        }

        this._humanTaskDef = v;
        this.refreshOperationParameter();
    }
    @Input()
    get createHumanTaskInstance() {
        return this._createHumanTaskInstance;
    }
    set createHumanTaskInstance(create: CreateHumanTaskInstance) {
        if (!create) {
            return;
        }

        this._createHumanTaskInstance = create;
        this.refreshOperationParameter();
    }

    private refreshOperationParameter() {
        const self = this;
        if (this._humanTaskDef && this._createHumanTaskInstance) {
            this._createHumanTaskInstance.operationParameters = {};
            this._humanTaskDef.operation.inputParameters.forEach(function (p: Parameter) {
                self._createHumanTaskInstance.operationParameters[p.name] = '';
            });
        }
    }
}