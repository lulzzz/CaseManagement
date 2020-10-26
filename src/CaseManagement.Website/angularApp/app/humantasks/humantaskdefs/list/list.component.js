var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatDialog, MatPaginator, MatSnackBar, MatSort } from '@angular/material';
import * as fromAppState from '@app/stores/appstate';
import * as fromHumanTaskDefActions from '@app/stores/humantaskdefs/actions/humantaskdef.actions';
import { ScannedActionsSubject, select, Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { merge } from 'rxjs';
import { filter } from 'rxjs/operators';
import { AddHumanTaskDefDialog } from './add-humantaskdef-dialog.component';
var ListHumanTaskDef = (function () {
    function ListHumanTaskDef(actions$, store, dialog, snackBar, translateService) {
        this.actions$ = actions$;
        this.store = store;
        this.dialog = dialog;
        this.snackBar = snackBar;
        this.translateService = translateService;
        this.displayedColumns = ['name', 'priority', 'create_datetime', 'update_datetime', 'actions'];
        this.humanTaskDefs$ = [];
        this.length = 0;
        this.baseTranslationKey = 'HUMANTASK.DEF.LIST';
    }
    ListHumanTaskDef.prototype.ngOnInit = function () {
        var _this = this;
        this.actions$.pipe(filter(function (action) { return action.type === fromHumanTaskDefActions.ActionTypes.COMPLETE_ADD_HUMANTASKDEF; }))
            .subscribe(function () {
            _this.snackBar.open(_this.translateService.instant(_this.baseTranslationKey + '.HUMANTASK_ADDED'), _this.translateService.instant('undo'), {
                duration: 2000
            });
            _this.refresh();
        });
        this.actions$.pipe(filter(function (action) { return action.type === fromHumanTaskDefActions.ActionTypes.ERROR_ADD_HUMANTASKDEF; }))
            .subscribe(function () {
            _this.snackBar.open(_this.translateService.instant(_this.baseTranslationKey + '.ERROR_ADD_HUMANTASK'), _this.translateService.instant('undo'), {
                duration: 2000
            });
        });
        this.store.pipe(select(fromAppState.selectHumanTasksResult)).subscribe(function (searchHumanTaskDefsResult) {
            if (!searchHumanTaskDefsResult) {
                return;
            }
            _this.humanTaskDefs$ = searchHumanTaskDefsResult.content;
            _this.length = searchHumanTaskDefsResult.totalLength;
        });
        this.refresh();
    };
    ListHumanTaskDef.prototype.ngAfterViewInit = function () {
        var _this = this;
        merge(this.sort.sortChange, this.paginator.page).subscribe(function () { return _this.refresh(); });
    };
    ListHumanTaskDef.prototype.addHumanTask = function () {
        var _this = this;
        var dialogRef = this.dialog.open(AddHumanTaskDefDialog, {
            width: '800px'
        });
        dialogRef.afterClosed().subscribe(function (e) {
            if (!e) {
                return;
            }
            var request = new fromHumanTaskDefActions.AddHumanTaskDefOperation(e.name);
            _this.store.dispatch(request);
        });
    };
    ListHumanTaskDef.prototype.refresh = function () {
        var startIndex = 0;
        var count = 5;
        if (this.paginator.pageIndex && this.paginator.pageSize) {
            startIndex = this.paginator.pageIndex * this.paginator.pageSize;
        }
        if (this.paginator.pageSize) {
            count = this.paginator.pageSize;
        }
        var active = "create_datetime";
        var direction = "desc";
        if (this.sort.active) {
            active = this.sort.active;
        }
        if (this.sort.direction) {
            direction = this.sort.direction;
        }
        var request = new fromHumanTaskDefActions.SearchHumanTaskDefOperation(active, direction, count, startIndex);
        this.store.dispatch(request);
    };
    __decorate([
        ViewChild(MatPaginator),
        __metadata("design:type", MatPaginator)
    ], ListHumanTaskDef.prototype, "paginator", void 0);
    __decorate([
        ViewChild(MatSort),
        __metadata("design:type", MatSort)
    ], ListHumanTaskDef.prototype, "sort", void 0);
    ListHumanTaskDef = __decorate([
        Component({
            selector: 'view-list-humantaskdef-component',
            templateUrl: './list.component.html',
            styleUrls: ['./list.component.scss'],
            encapsulation: ViewEncapsulation.None
        }),
        __metadata("design:paramtypes", [ScannedActionsSubject,
            Store,
            MatDialog,
            MatSnackBar,
            TranslateService])
    ], ListHumanTaskDef);
    return ListHumanTaskDef;
}());
export { ListHumanTaskDef };
//# sourceMappingURL=list.component.js.map