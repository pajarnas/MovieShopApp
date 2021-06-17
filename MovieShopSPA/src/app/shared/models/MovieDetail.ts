 

    export interface MovieDetail {
        id: number;
        title: string;
        overview: string;
        tagline: string;
        budget: number;
        revenue: number;
        imdbUrl: string;
        posterUrl: string;
        backdropUrl: string;
        originalLanguage: string;
        releaseDate: string;
        runTime: number;
        price: number;
        createdDate?: any;
        updatedDate?: any;
        updatedBy?: any;
        createdBy?: any;
        rating: number;
        casts: Cast[];
        genres: Genre[];
        
    }
    export interface Cast {
        id: number;
        name: string;
        gender: string;
        tmdbUrl: string;
        profilePath: string;
        character: string;
    }

    export interface Genre {
        id: number;
        name: string;
    }

 