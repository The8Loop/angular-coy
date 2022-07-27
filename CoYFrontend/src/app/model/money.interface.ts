import { Byte } from "@angular/compiler/src/util";

//Backend: MoneyDTO
export interface MoneyDTO {
    contribution: number;
    date: Date;
    contributionType: string;
    contributionTypeId: number;
    userId: number;
}

export interface MoneyPostDTO {
    contribution: number;
    contributionTypeId: number;
    userId: number;
}

export interface ContributionTypeDTO {
    id: number;
    contributionType: string;
}

export interface TotalSP {
    total: number;
}