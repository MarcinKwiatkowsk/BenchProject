import { Component, Injectable, Input } from "@angular/core";

export class Company{    

    name: string;
    code: string;
    description: string;

    constructor(_name: string, _code: string, _description: string) {
        this.name = _name;
        this.code = _code;
        this.description = _description;        
    }
}