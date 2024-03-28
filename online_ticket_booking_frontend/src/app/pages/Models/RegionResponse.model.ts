export interface RegionResponse {
    listregion: Region[],
    isSuccess: boolean,
    statusMessage: string
  }

  export interface Region {
    id: number,
    region_name: string
  }