export interface Booking {
  bus_name?: string;
  booking_id?: number;
  user_id?: number;
  route_id?: number;
  bus_id?: number;
  ending_time: Date;
  seat_no?: string;
  isBooked?: boolean;
  isPaid: boolean;
  username?: string;
  email?: string;
  phone_number?: string; 
}

// export interface User {
//   user_id: number;
//   username?: string;
//   email?: string;
//   password?: string;
//   isActive: boolean;
//   phone_number?: string;
// }

export interface BookingResponse {
  isSuccess: boolean;
  statusMessage?: string;
  bookingList?: Booking[];
}