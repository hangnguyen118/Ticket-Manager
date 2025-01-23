export interface Menu {
  label: string;
  link: string;
  links?: Menu[];
}

export interface Movie {
  title: string;
  description?: string;
  genre: string[],
  director?: string;
  posterUrl: string;
  trailerUrl?: string;  
  rating?: string;
  isAvailable?: boolean;
  release_day: string;
  duration: number;
  age_rating: number;
}
