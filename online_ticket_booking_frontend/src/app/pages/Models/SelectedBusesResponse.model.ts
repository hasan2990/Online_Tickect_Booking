export interface SelectedBusesResponse {
    serviceGetBuses: PriceInfo[],
    isSuccess: boolean,
    statusMessage: string
  }
  
  export interface PriceInfo {
    bus_id: number,
    bus_name: string,
    route_id: number,
    capacity: number,
    seatCount: number,
    source: string,
    destination: string,
    price: number,
  }
  