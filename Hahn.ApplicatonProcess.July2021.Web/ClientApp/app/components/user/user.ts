interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    age: number;
    address: Address;
    assets: Asset[];
}

interface Address {
    postalCode: string;
    street: string;
    houseNo: string;
}
