export interface Person {
    id: number;
    name: string;
    cpf: string;
    age: number;
}

export interface Customer extends Person {
    phone: string;
    email: string;
    address: string;
    dependents?: Dependent[];
}

export interface Dependent extends Person {
    relationship: string;
    customer?: Customer
}
