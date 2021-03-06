﻿import { Component, EventEmitter, Output, ViewEncapsulation, Input } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { Parameter } from '@app/stores/common/parameter.model';
import { TranslateService } from '@ngx-translate/core';

export class ParameterType {
    constructor(public type: string, public displayName: string) { }
}

@Component({
    selector: 'operationparameter-component',
    templateUrl: './operationparameter.component.html',
    encapsulation: ViewEncapsulation.None
})
export class OperationParameterComponent {
    parameterTypes: ParameterType[];
    parameterForm: FormGroup;
    @Input() usage: string;
    @Input() parameters: Parameter[] = [];

    @Output() parameterAdded = new EventEmitter<Parameter>();
    @Output() parameterRemoved = new EventEmitter<Parameter>();

    constructor(
        private translateService: TranslateService,
        private snackBar: MatSnackBar,
        private formBuilder: FormBuilder) {
        this.parameterTypes = [];
        this.parameterTypes.push(new ParameterType("STRING", "string"));
        this.parameterTypes.push(new ParameterType("BOOL", "boolean"));
        this.parameterForm = this.formBuilder.group({
            name: new FormControl('', [
                Validators.required
            ]),
            type: new FormControl('', [
                Validators.required
            ]),
            isRequired: ''
        });
    }

    addParameter(param: Parameter) {
        if (!this.parameterForm.valid) {
            return;
        }

        const filteredOutputParam = this.parameters.filter(function (p: Parameter) {
            return p.name === param.name
        });
        if (filteredOutputParam.length === 1) {
            this.snackBar.open(this.translateService.instant('SHARED.PARAMETER_EXISTS'), this.translateService.instant('undo'), {
                duration: 2000
            });
            return;
        }

        if (!param.isRequired) {
            param.isRequired = false;
        }

        param.usage = this.usage;
        this.parameters.push(param);
        this.parameterForm.reset();
        this.parameterAdded.emit(param);
    }

    deleteParameter(param: Parameter) {
        const index = this.parameters.indexOf(param);
        this.parameters.splice(index, 1);
        this.parameterRemoved.emit(param);
    }
}
