﻿import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import * as fromAppState from '@app/stores/appstate';
import { OptionValue, OutputRenderingElement, Rendering, Translation } from '@app/stores/common/rendering.model';
import * as fromHumanTaskDefActions from '@app/stores/humantaskdefs/actions/humantaskdef.actions';
import { HumanTaskDef } from '@app/stores/humantaskdefs/models/humantaskdef.model';
import { select, Store, ScannedActionsSubject } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { filter } from 'rxjs/operators';

export class Language {
    constructor(public code: string, public display: string) { }
}

export class FieldType {
    constructor(public displayName: string, public fieldType: string) { }
}

@Component({
    selector: 'view-humantaskdef-rendering-component',
    templateUrl: './rendering.component.html',
    styleUrls: ['./rendering.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class ViewHumanTaskDefRenderingComponent implements OnInit {
    baseTranslationKey: string = "HUMANTASK.DEF.VIEW.RENDERING";
    addLabelForm: FormGroup;
    addValueForm: FormGroup;
    id: string;
    selectedField: OutputRenderingElement;
    rendering: Rendering = new Rendering();
    languages: Language[];
    fieldTypes: FieldType[];

    constructor(
        private store: Store<fromAppState.AppState>,
        private formBuilder: FormBuilder,
        private snackBar: MatSnackBar,
        private translateService: TranslateService,
        private actions$: ScannedActionsSubject) {
        this.addLabelForm = this.formBuilder.group({
            language: '',
            value: ''
        });
        this.addValueForm = this.formBuilder.group({
            value: '',
            language: '',
            translation: ''
        });
        this.languages = [];
        this.fieldTypes = [];
        const french = new Language("fr", "French");
        const english = new Language("en", "English");
        this.languages.push(french);
        this.languages.push(english);
        this.fieldTypes.push(new FieldType(this.baseTranslationKey + ".TEXT", "string"));
        this.fieldTypes.push(new FieldType(this.baseTranslationKey + ".SELECT", "select"));
    }

    ngOnInit(): void {
        this.actions$.pipe(
            filter((action: any) => action.type === fromHumanTaskDefActions.ActionTypes.COMPLETE_UPDATE_RENDERING_PARAMETER))
            .subscribe(() => {
                this.snackBar.open(this.translateService.instant(this.baseTranslationKey + '.RENDERING_UPDATED'), this.translateService.instant('undo'), {
                    duration: 2000
                });
            });
        this.actions$.pipe(
            filter((action: any) => action.type === fromHumanTaskDefActions.ActionTypes.ERROR_UPDATE_RENDERING_PARAMETER))
            .subscribe(() => {
                this.snackBar.open(this.translateService.instant(this.baseTranslationKey + '.ERROR_UPDATE_RENDERING'), this.translateService.instant('undo'), {
                    duration: 2000
                });
            });
        this.store.pipe(select(fromAppState.selectHumanTaskResult)).subscribe((e: HumanTaskDef) => {
            if (!e) {
                return;
            }

            this.id = e.id;
            this.rendering = e.rendering;
        });
    }

    drop(event: CdkDragDrop<string[]>) {
        moveItemInArray(this.rendering.output, event.previousIndex, event.currentIndex);
    }

    updateLabel(translation: Translation) {
        if (!this.selectedField) {
            return;
        }

        const filteredLabels = this.selectedField.label.filter(function (l: Translation) {
            return l.language === translation.language;
        });
        if (filteredLabels.length === 1) {
            this.snackBar.open(this.translateService.instant(this.baseTranslationKey + '.TRANSLATION_EXISTS'), this.translateService.instant('undo'), {
                duration: 2000
            });
            return;
        }

        this.selectedField.label.push(translation);
        this.addLabelForm.reset();
    }

    addValue(form : any) {
        if (!this.selectedField || this.selectedField.value.type !== 'select') {
            return;
        }

        const filteredValue = this.selectedField.value.values.filter(function (f: OptionValue) {
            return f.value === form.value && f.displayNames.filter(function (d: Translation) {
                return d.language === form.language;
            }).length > 0;
        });
        if (filteredValue.length === 1) {
            this.snackBar.open(this.translateService.instant(this.baseTranslationKey + '.VALUE_EXISTS'), this.translateService.instant('undo'), {
                duration: 2000
            });
            return;
        }

        const optValue = new OptionValue();
        optValue.value = form.value;
        optValue.displayNames.push(new Translation(form.language, form.translation));
        this.selectedField.value.values.push(optValue);
        this.addValueForm.reset();
    }

    addField(fieldType: FieldType) {
        const renderingElt = new OutputRenderingElement();
        renderingElt.value.type = fieldType.fieldType;
        this.rendering.output.push(renderingElt);
    }

    removeField(elt: OutputRenderingElement) {
        const index = this.rendering.output.indexOf(elt);
        this.rendering.output.splice(index, 1);
        this.selectedField = null;
    }

    displaySettings(elt: OutputRenderingElement) {
        this.selectedField = elt;
    }

    deleteValue(val: OptionValue) {
        if (!this.selectedField) {
            return;
        }

        const index = this.selectedField.value.values.indexOf(val);
        this.selectedField.value.values.splice(index, 1);
    }

    deleteLabel(lbl: Translation) {
        if (!this.selectedField) {
            return;
        }

        const index = this.selectedField.label.indexOf(lbl);
        this.selectedField.label.splice(index, 1);
    }

    joinDisplayNames(val: OptionValue) {
        const map = new Map();
        val.displayNames.forEach((item) => {
            const key = item.language;
            const collection = map.get(key);
            if (!collection) {
                map.set(key, [item]);
            } else {
                collection.push(item);
            }
        });

        var arr : any = [];
        map.forEach(function (value, key) {
            arr.push(key + "="+value[0].value);
        });

        return val.value + "("+arr.join(',')+")";
    }

    update() {
        const request = new fromHumanTaskDefActions.UpdateRenderingOperation(this.id ,this.rendering);
        this.store.dispatch(request);
    }
}
