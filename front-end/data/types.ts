export interface Menu {
  label: string;
  link: string;
  links?: Menu[];
}

export interface Movie {
  id: string;
  title: string;
  description?: string;
  genre: string[],
  director?: string;
  posterUrl: string;
  trailerUrl?: string;  
  rating: number;
  isAvailable?: boolean;
  release_day: string;
  duration: number;
  age_rating: number;
}