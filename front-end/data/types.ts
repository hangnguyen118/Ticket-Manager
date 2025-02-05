export interface Menu {
  label: string;
  link: string;
  links?: Menu[];
}

export interface Movie {
  title: string;
  description?: string;
  genre: string[];
  director?: string;
  posterUrl: string;
  trailerUrl?: string;
  rating: number;
  isAvailable?: boolean;
  release_day: string;
  duration: number;
  age_rating: number;
}
export interface Hall {
  cinema_id: number,
  name: string,
  total_seats: number
}
export interface Seat {
  id: number,
  row: string;
  number: number;
  seat_type: number;
  status: boolean;
}
