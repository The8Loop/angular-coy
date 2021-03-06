export interface LodestoneTopic {
    url: string;
    time: string;
    image: string;
    description: string;
}

export interface Response {
    url: string;
    title: string;
    start: string;
    end: string;
    current: boolean;
}

export interface LodestoneMaintenance {
    companion: Response[];
    game: Response[];
}