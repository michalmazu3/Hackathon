export class Field {
  id: number;
  name: string;
  cordinates: Cordinate[];
  orders: Order[];
}

export class Order {
  id: number;
  fieldId: number;
  field?: any;
  executiveId: number;
  executive?: any;
  deadlineDate: string;
  finishDate: string;
}

export class Cordinate {
  id: number;
  latitude: number;
  longitude: number;
  field?: any;
}
