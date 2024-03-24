import { ObjectId } from 'mongodb';

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
  _id: string;
  date: Date;
  listing_id: string;
  reviewer_id: string;
  reviewer_name: string;
  comments: string;
}

interface Host {
  host_id: string;
  host_url: string;
  host_name: string;
  host_location: string;
  host_about: string;
  host_response_time: string;
  host_thumbnail_url: string;
  host_picture_url: string;
  host_neighbourhood: string;
  host_response_rate: {
    $numberInt: string;
  };
  host_is_superhost: boolean;
  host_has_profile_pic: boolean;
  host_identity_verified: boolean;
  host_listings_count: {
    $numberInt: string;
  };
  host_total_listings_count: {
    $numberInt: string;
  };
  host_verifications: string[];
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

interface Availability {
  availability_30: {
    $numberInt: string;
  };
  availability_60: {
    $numberInt: string;
  };
  availability_90: {
    $numberInt: string;
  };
  availability_365: {
    $numberInt: string;
  };
}

interface ReviewScores {
  review_scores_accuracy: {
    $numberInt: string;
  };
  review_scores_cleanliness: {
    $numberInt: string;
  };
  review_scores_checkin: {
    $numberInt: string;
  };
  review_scores_communication: {
    $numberInt: string;
  };
  review_scores_location: {
    $numberInt: string;
  };
  review_scores_value: {
    $numberInt: string;
  };
  review_scores_rating: {
    $numberInt: string;
  };
}

export interface Listing {
  _id: ObjectId;
  listing_url: string;
  name: string;
  description: string;
  interaction: string;
  house_rules: string;
  property_type: string;
  room_type: string;
  bed_type: string;
  minimum_nights: string;
  maximum_nights: string;
  cancellation_policy: string;
  last_scraped: {
    $date: {
      $numberLong: string;
    };
  };
  calendar_last_scraped: {
    $date: {
      $numberLong: string;
    };
  };
  first_review: {
    $date: {
      $numberLong: string;
    };
  };
  last_review: {
    $date: {
      $numberLong: string;
    };
  };
  accommodates: {
    $numberInt: string;
  };
  bedrooms: {
    $numberInt: string;
  };
  beds: {
    $numberInt: string;
  };
  number_of_reviews: {
    $numberInt: string;
  };
  bathrooms: {
    $numberDecimal: string;
  };
  amenities: string[];
  price: {
    $numberDecimal: string;
  };
  security_deposit: {
    $numberDecimal: string;
  };
  cleaning_fee: {
    $numberDecimal: string;
  };
  extra_people: {
    $numberDecimal: string;
  };
  guests_included: {
    $numberDecimal: string;
  };
  images: {
    thumbnail_url: string;
    medium_url: string;
    picture_url: string;
    xl_picture_url: string;
  };
  host: Host;
  address: Address;
  availability: Availability;
  review_scores: ReviewScores;
  reviews: Review[];
}
