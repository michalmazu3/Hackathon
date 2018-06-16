export class Field {
  id: number;
  name: string;
  cordinates: Cordinate[];
  orders: Order[];
  ratings: Rating[];

}

export class Order {
  id: number;
  fieldId: number;
  field?: any;
  executiveId: number;
  executive?: Executive;
  deadlineDate: string;
  finishDate: string;
  status: number
}

export class Cordinate {
  id: number;
  latitude: number;
  longitude: number;
  field?: Field;
}
export class Rating {
  id: number;
  score: number;
  user: string;
  fieldId: number;
  field?: Field;

}

export class Executive {
  id: number;
  name: string;

}
export class Alerts {

  id: number;
  title: string;
  message: string;
  startDate?: string;
  endDate?: string;

}
