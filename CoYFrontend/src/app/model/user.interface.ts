import { MoneyDTO } from "./money.interface";

//Backend: UserDTO
export interface User {
    id: number;
    name: string;
}

export interface UserContribution {
    name: string;
    contributions: MoneyDTO[];
}

export interface UserLogin {
    name: string;
    password: string;
}

export interface Leaderboard {
    name: string;
    total: number;
}

export interface SessionDTO {
    sessionString: string;
    userId: number;
}