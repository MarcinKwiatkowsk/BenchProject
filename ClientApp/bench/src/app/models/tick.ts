export class Tick{    

    constructor(_tickId: string, _dateTime: string, _value: number) {
        this.TickId = _tickId;
        this.TickDateTime = _dateTime;
        this.TickValue =  _value;        
    }

    private TickId: string ='';
    private TickDateTime: string = '';
    private TickValue: number =0; 

    get getId() {return this.TickId;}
    set setId(id: string) {this.TickId = id;}

    get getDate() {return this.TickDateTime;}
    set setDate(date: string) {this.TickDateTime = date;}

    get getValue() {return this.TickValue;}
    set setValue(value: number) {this.TickValue = value;}
}