//Backend: UserDTO
export interface User {
    id: number;
    name: string;
}

export interface UserContribution {
    name: string;
    contributions: number[];
}