interface Location {
  type: string;
  coordinates: [
    {
      $numberDouble: string;
    },
    {
      $numberDouble: string;
    }
  ];
  is_location_exact: boolean;
}

export interface Review {
  reviewer_name: string;
  comments: string;
}

interface Address {
  street: string;
  suburb: string;
  government_area: string;
  market: string;
  country: string;
  country_code: string;
  location: Location;
}

export interface Listing {
  id: string;
  name: string;
  description: string;
  bedrooms: {
    $numberInt: string;
  };
  beds: {
    $numberInt: string;
  };
  bathrooms: {
    $numberDecimal: string;
  };
  images: {
    thumbnail_url: string;
    medium_url: string;
    picture_url: string;
    xl_picture_url: string;
  };
  address: Address;
  reviews: Review[];
}
