//Backend: MoneyDTO
export interface MoneyDTO {
    contribution: number;
    date: Date;
    contributionType: string;
    contributionTypeId: number;
    userId: number;
}

export interface TotalSP {
    total: number;
}