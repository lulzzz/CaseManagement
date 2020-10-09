﻿import { ToPart } from "./topart.model";
import { NotificationDefinition } from "./notificationdefinition.model";

export class Escalation {
    constructor() {
        this.toParts = [];
        this.notification = new NotificationDefinition();
    }

    condition: string;
    toParts: ToPart[];
    notification: NotificationDefinition;
}