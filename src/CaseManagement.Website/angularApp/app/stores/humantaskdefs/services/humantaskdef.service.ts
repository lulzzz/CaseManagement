import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable, of } from 'rxjs';
import { Escalation } from '../../common/escalation.model';
import { Parameter } from '../../common/operation.model';
import { Rendering } from '../../common/rendering.model';
import { HumanTaskDefAssignment } from '../models/humantaskdef-assignment.model';
import { HumanTaskDefinitionDeadLine } from '../models/humantaskdef-deadlines';
import { HumanTaskDef } from '../models/humantaskdef.model';
import { SearchHumanTaskDefsResult } from '../models/searchhumantaskdef.model';

function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

@Injectable()
export class HumanTaskDefService {
    constructor(private http: HttpClient, private oauthService: OAuthService) { }

    get(humanTaskDefId: string): Observable<HumanTaskDef> {
        let headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        const targetUrl = process.env.HUMANTASK_API_URL + "/humantasksdefs/" + humanTaskDefId;
        return this.http.get<HumanTaskDef>(targetUrl, { headers: headers });
    }

    update(humanTaskDef: HumanTaskDef): Observable<HumanTaskDef> {
        return of(humanTaskDef);
    }

    addStartDeadline(id: string, deadline: HumanTaskDefinitionDeadLine): Observable<HumanTaskDefinitionDeadLine> {
        if (id) { }
        if (deadline) { }

        deadline.id = uuidv4();
        return of(deadline);
    }

    addCompletionDeadline(id: string, deadline: HumanTaskDefinitionDeadLine): Observable<HumanTaskDefinitionDeadLine> {
        if (id) { }
        if (deadline) { }

        deadline.id = uuidv4();
        return of(deadline);
    }

    updateInfo(id: string, name: string, priority: number): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        const targetUrl = process.env.HUMANTASK_API_URL + "/humantasksdefs/" + id + "/info";
        const request: any = { name: name, priority: priority};
        return this.http.put<boolean>(targetUrl, JSON.stringify(request), { headers: headers });
    }

    addInputParameter(id: string, parameter: Parameter): Observable<boolean> {
        if (id) { }
        if (parameter) { }

        return of(true);
    }

    addOutputParameter(id: string, parameter: Parameter): Observable<boolean> {
        if (id) { }
        if (parameter) { }

        return of(true);
    }

    deleteInputParameter(id: string, name: string): Observable<boolean> {
        if (id) { }
        if (name) { }

        return of(true);
    }

    deleteOutputParameter(id: string, name: string): Observable<boolean> {
        if (id) { }
        if (name) { }

        return of(true);
    }

    updateRendering(id: string, rendering: Rendering): Observable<boolean> {
        if (id) { }
        if (rendering) { }

        return of(true);
    }

    deleteStartDeadline(id: string, name: string): Observable<boolean> {
        if (id) { }
        if (name) { }

        return of(true);
    }

    deleteCompletionDeadline(id: string, name: string): Observable<boolean> {
        if (id) { }
        if (name) { }

        return of(true);
    }

    updateStartDealine(id: string, deadline: HumanTaskDefinitionDeadLine): Observable<boolean> {
        if (id) { }
        if (deadline) { }

        return of(true);
    }

    updateCompletionDealine(id: string, deadline: HumanTaskDefinitionDeadLine): Observable<boolean> {
        if (id) { }
        if (deadline) { }

        return of(true);
    }

    addEscalationStartDeadline(id: string, startDeadlineId: string, condition: string): Observable<string> {
        if (id) { }
        if (startDeadlineId) { }
        if (condition) { }

        return of(uuidv4());
    }

    addEscalationCompletionDeadline(id: string, startDeadlineId: string, condition: string): Observable<string> {
        if (id) { }
        if (startDeadlineId) { }
        if (condition) { }

        return of(uuidv4());
    }

    updatePeopleAssignment(id: string, assignment: HumanTaskDefAssignment): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        const request: any = { peopleAssignment: assignment };
        const targetUrl = process.env.HUMANTASK_API_URL + "/humantasksdefs/" + id + "/assignment";
        return this.http.put<boolean>(targetUrl, JSON.stringify(request), { headers: headers });
    }

    updateStartEscalation(id: string, deadLineId: string, escalation: Escalation): Observable<boolean> {
        if (id) { }
        if (deadLineId) { }
        if (escalation) { }

        return of(true);
    }

    updateCompletionEscalation(id: string, deadLineId: string, escalation: Escalation): Observable<boolean> {
        if (id) { }
        if (deadLineId) { }
        if (escalation) { }

        return of(true);
    }

    deleteCompletionEscalation(id: string, deadLineId: string, escalation: Escalation): Observable<boolean> {
        if (id) { }
        if (deadLineId) { }
        if (escalation) { }

        return of(true);
    }

    deleteStartEscalation(id: string, deadLineId: string, escalation: Escalation): Observable<boolean> {
        if (id) { }
        if (deadLineId) { }
        if (escalation) { }

        return of(true);
    }

    addHumanTask(name: string): Observable<HumanTaskDef> {
        let headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        const request: any = { name: name };
        const targetUrl = process.env.HUMANTASK_API_URL + "/humantasksdefs";
        return this.http.post<HumanTaskDef>(targetUrl, request, { headers: headers });
    }

    search(startIndex: number, count: number, order: string, direction: string): Observable<SearchHumanTaskDefsResult> {
        let headers = new HttpHeaders();
        headers = headers.set('Accept', 'application/json');
        headers = headers.set('Content-Type', 'application/json');
        headers = headers.set('Authorization', 'Bearer ' + this.oauthService.getIdToken());
        const targetUrl = process.env.HUMANTASK_API_URL + "/humantasksdefs/.search";
        const request: any = { startIndex: startIndex, count: count };
        if (order) {
            request["orderBy"] = order;
        }

        if (direction) {
            request["order"] = direction;
        }

        return this.http.post<SearchHumanTaskDefsResult>(targetUrl, JSON.stringify(request), { headers: headers });
    }
}