interface Order {
  id: string;
  object: string;
  amount: string;
  amount_refunded: string;
  created: Date;
  billing_details: object;
  Customer: object;
  Description: string;
  FailureCode: string;
  FailureMessage: string;
  paid: string;
  refunded: string;
  status: string;
  payment_method_details: object;
  refunds: object;
}
