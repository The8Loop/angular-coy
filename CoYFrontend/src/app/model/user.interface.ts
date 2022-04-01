//Backend: UserDTO
export interface User {
    id: number;
    name: string;
}

export interface UserCont {
    name: string;
    contributions: number[];
}