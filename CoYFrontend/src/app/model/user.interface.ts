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

export interface Leaderboard {
    name: string;
    total: number;
}