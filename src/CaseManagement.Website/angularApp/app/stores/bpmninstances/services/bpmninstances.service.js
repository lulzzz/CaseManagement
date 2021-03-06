var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
var BpmnInstancesService = (function () {
    function BpmnInstancesService(http, oauthService) {
        this.http = http;
        this.oauthService = oauthService;
    }
    BpmnInstancesService.prototype.search = function (startIndex, count, order, direction, processFileId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.BPMN_API_URL + "/processinstances/search";
        var request = { startIndex: startIndex, count: count };
        if (order) {
            request["orderBy"] = order;
        }
        if (direction) {
            request["order"] = direction;
        }
        if (processFileId) {
            request["processFileId"] = processFileId;
        }
        return this.http.post(targetUrl, JSON.stringify(request), { headers: headers });
    };
    BpmnInstancesService.prototype.get = function (id) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.BPMN_API_URL + "/processinstances/" + id;
        return this.http.get(targetUrl, { headers: headers });
    };
    BpmnInstancesService.prototype.create = function (processFileId) {
        var headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.BPMN_API_URL + "/processinstances";
        var request = { processFileId: processFileId };
        return this.http.post(targetUrl, JSON.stringify(request), { headers: headers });
    };
    BpmnInstancesService.prototype.start = function (id) {
        var headers = new HttpHeaders();
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        var targetUrl = process.env.BPMN_API_URL + "/processinstances/" + id + "/start";
        return this.http.get(targetUrl, { headers: headers });
    };
    BpmnInstancesService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient, OAuthService])
    ], BpmnInstancesService);
    return BpmnInstancesService;
}());
export { BpmnInstancesService };
//# sourceMappingURL=bpmninstances.service.js.map