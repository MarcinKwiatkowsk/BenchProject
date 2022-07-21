import { Component, Injectable, Input } from "@angular/core";

export class Tick{    

    id: string;
    tickDateTime: string;
    tickValue: number;

    constructor(_tickId: string, _dateTime: string, _value: number, _companyCode: string) {
        this.id = _tickId;
        this.tickDateTime = _dateTime;
        this.tickValue =  _value;              
    }
}