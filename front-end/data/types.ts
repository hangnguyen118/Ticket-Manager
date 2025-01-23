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
  releaseDate?: string;
  rating?: string;
  isAvailable?: boolean;
}
