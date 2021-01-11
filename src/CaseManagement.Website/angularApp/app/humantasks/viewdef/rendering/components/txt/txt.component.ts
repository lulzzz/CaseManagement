﻿import { Component, Inject } from "@angular/core";
import { BaseUIComponent } from "../baseui.component";
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from "@angular/material";
import { FormGroup, FormControl } from "@angular/forms";

@Component({
    selector: 'view-txt',
    templateUrl: 'txt.component.html',
    styleUrls: ['./txt.component.scss']
})
export class TxtComponent extends BaseUIComponent {
    constructor(private dialog: MatDialog) {
        super();
    }

    openDialog() {
        const dialogRef = this.dialog.open(TxtComponentDialog, {
            data: { opt: this.option }
        });
        dialogRef.afterClosed().subscribe((r: any) => {
            if (!r) {
                return;
            }
        });
    }
}

@Component({
    selector: 'view-txt-dialog',
    templateUrl: 'txtdialog.component.html',
})
export class TxtComponentDialog {
    configureTxtForm: FormGroup;
    constructor(
        @Inject(MAT_DIALOG_DATA) public data: any,
        public dialogRef: MatDialogRef<TxtComponentDialog>
    ) {
        this.configureTxtForm = new FormGroup({
            label: new FormControl({ value: '' }),
            name: new FormControl({ value: '' })
        });
        this.configureTxtForm.get('label').setValue(data.opt.label);
        this.configureTxtForm.get('name').setValue(data.opt.name);
    }

    onSave(val: { label: string, name: string}) {
        const opt = this.data.opt;
        this.data.opt.label = val.label;
        this.data.opt.name = val.name;
        this.dialogRef.close(opt);
    }
}