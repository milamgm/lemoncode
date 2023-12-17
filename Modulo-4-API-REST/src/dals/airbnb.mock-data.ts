import { ObjectId } from 'mongodb';
import { Listing } from './listing/index.js';

export interface DB {
  listingsAndReviews: Listing[];
}

export const db: DB = {
  listingsAndReviews: [
    {
      _id: new ObjectId('657b681b8f6db62a054cbceb'),
      listing_url: 'https://www.airbnb.com/rooms/10006546',
      name: 'Ribeira Charming Duplex',
      description:
        'Fantastic duplex apartment with three bedrooms, located in the historic area of Porto, Ribeira (Cube)...',
      interaction: 'Cot - 10 € / night Dog - € 7,5 / night',
      house_rules: 'Make the house your home...',
      property_type: 'House',
      room_type: 'Entire home/apt',
      bed_type: 'Real Bed',
      minimum_nights: '2',
      maximum_nights: '30',
      cancellation_policy: 'moderate',
      last_scraped: {
        $date: {
          $numberLong: '1550293200000',
        },
      },
      calendar_last_scraped: {
        $date: {
          $numberLong: '1550293200000',
        },
      },
      first_review: {
        $date: {
          $numberLong: '1451797200000',
        },
      },
      last_review: {
        $date: {
          $numberLong: '1547960400000',
        },
      },
      accommodates: {
        $numberInt: '8',
      },
      bedrooms: {
        $numberInt: '3',
      },
      beds: {
        $numberInt: '5',
      },
      number_of_reviews: {
        $numberInt: '51',
      },
      bathrooms: {
        $numberDecimal: '1.0',
      },
      amenities: [
        'TV',
        'Cable TV',
        'Wifi',
        'Kitchen',
        'Paid parking off premises',
        'Smoking allowed',
        'Pets allowed',
        'Buzzer/wireless intercom',
        'Heating',
        'Family/kid friendly',
        'Washer',
        'First aid kit',
        'Fire extinguisher',
        'Essentials',
        'Hangers',
        'Hair dryer',
        'Iron',
        'Pack ’n Play/travel crib',
        'Room-darkening shades',
        'Hot water',
        'Bed linens',
        'Extra pillows and blankets',
        'Microwave',
        'Coffee maker',
        'Refrigerator',
        'Dishwasher',
        'Dishes and silverware',
        'Cooking basics',
        'Oven',
        'Stove',
        'Cleaning before checkout',
        'Waterfront',
      ],
      price: {
        $numberDecimal: '80.00',
      },
      security_deposit: {
        $numberDecimal: '200.00',
      },
      cleaning_fee: {
        $numberDecimal: '35.00',
      },
      extra_people: {
        $numberDecimal: '15.00',
      },
      guests_included: {
        $numberDecimal: '6',
      },
      images: {
        thumbnail_url: '',
        medium_url: '',
        picture_url:
          'https://a0.muscache.com/im/pictures/e83e702f-ef49-40fb-8fa0-6512d7e26e9b.jpg?aki_policy=large',
        xl_picture_url: '',
      },
      host: {
        host_id: '51399391',
        host_url: 'https://www.airbnb.com/users/show/51399391',
        host_name: 'Ana&Gonçalo',
        host_location: 'Porto, Porto District, Portugal',
        host_about:
          'Gostamos de passear, de viajar, de conhecer pessoas e locais novos, gostamos de desporto e animais! Vivemos na cidade mais linda do mundo!!!',
        host_response_time: 'within an hour',
        host_thumbnail_url:
          'https://a0.muscache.com/im/pictures/fab79f25-2e10-4f0f-9711-663cb69dc7d8.jpg?aki_policy=profile_small',
        host_picture_url:
          'https://a0.muscache.com/im/pictures/fab79f25-2e10-4f0f-9711-663cb69dc7d8.jpg?aki_policy=profile_x_medium',
        host_neighbourhood: '',
        host_response_rate: {
          $numberInt: '100',
        },
        host_is_superhost: false,
        host_has_profile_pic: true,
        host_identity_verified: true,
        host_listings_count: {
          $numberInt: '3',
        },
        host_total_listings_count: {
          $numberInt: '3',
        },
        host_verifications: [
          'email',
          'phone',
          'reviews',
          'jumio',
          'offline_government_id',
          'government_id',
        ],
      },
      address: {
        street: 'Porto, Porto, Portugal',
        suburb: '',
        government_area: 'Cedofeita, Ildefonso, Sé, Miragaia, Nicolau, Vitória',
        market: 'Porto',
        country: 'Portugal',
        country_code: 'PT',
        location: {
          type: 'Point',
          coordinates: [
            {
              $numberDouble: '-8.61308',
            },
            {
              $numberDouble: '41.1413',
            },
          ],
          is_location_exact: false,
        },
      },
      availability: {
        availability_30: {
          $numberInt: '28',
        },
        availability_60: {
          $numberInt: '47',
        },
        availability_90: {
          $numberInt: '74',
        },
        availability_365: {
          $numberInt: '239',
        },
      },
      review_scores: {
        review_scores_accuracy: {
          $numberInt: '9',
        },
        review_scores_cleanliness: {
          $numberInt: '9',
        },
        review_scores_checkin: {
          $numberInt: '10',
        },
        review_scores_communication: {
          $numberInt: '10',
        },
        review_scores_location: {
          $numberInt: '10',
        },
        review_scores_value: {
          $numberInt: '9',
        },
        review_scores_rating: {
          $numberInt: '89',
        },
      },
      reviews: [
        {
          _id: '362865132',
          date: new Date(2023, 8, 19),
          listing_id: '10006546',
          reviewer_id: '208880077',
          reviewer_name: 'Thomas',
          comments: 'Very helpful hosts. Cooked traditional...',
        },
        {
          _id: '364728730',
          date: new Date(2023, 7, 5),
          listing_id: '10006546',
          reviewer_id: '91827533',
          reviewer_name: 'Mr',
          comments: 'Ana & Goncalo were great on communication...',
        },
        {
          _id: '403055315',
          date: new Date(2023, 5, 15),
          listing_id: '10006546',
          reviewer_id: '15138940',
          reviewer_name: 'Milo',
          comments: 'The house was extremely well located...',
        },
        {
          _id: '403075315',
          date: new Date(2023, 4, 5),
          listing_id: '10006146',
          reviewer_id: '15134640',
          reviewer_name: 'Mike',
          comments: 'Was great!',
        },
        {
          _id: '405555315',
          date: new Date(2023, 9, 8),
          listing_id: '10007896',
          reviewer_id: '15136540',
          reviewer_name: 'Sam',
          comments: 'Perfect restaurant',
        },
        {
          _id: '405587315',
          date: new Date(2023, 3, 6),
          listing_id: '10065896',
          reviewer_id: '15137640',
          reviewer_name: 'Lisa',
          comments: 'The bedroom was huge!',
        },
      ],
    },
    {
      _id: new ObjectId('657b681b8f6db62a054cbced'),
      listing_url: 'https://www.airbnb.com/rooms/98765432',
      name: 'Sunset Beach Villa',
      description:
        'Enjoy breathtaking sunsets at this luxurious beachfront villa with panoramic views of the ocean.',
      interaction:
        'We provide concierge service to assist you with any needs during your stay.',
      house_rules:
        'No smoking, no parties. Please treat our home with respect.',
      property_type: 'Villa',
      room_type: 'Entire home/apt',
      bed_type: 'King Bed',
      minimum_nights: '3',
      maximum_nights: '14',
      cancellation_policy: 'strict',
      last_scraped: {
        $date: {
          $numberLong: '1678924800000',
        },
      },
      calendar_last_scraped: {
        $date: {
          $numberLong: '1678924800000',
        },
      },
      first_review: {
        $date: {
          $numberLong: '1654022400000',
        },
      },
      last_review: {
        $date: {
          $numberLong: '1677523200000',
        },
      },
      accommodates: {
        $numberInt: '10',
      },
      bedrooms: {
        $numberInt: '5',
      },
      beds: {
        $numberInt: '7',
      },
      number_of_reviews: {
        $numberInt: '30',
      },
      bathrooms: {
        $numberDecimal: '4.5',
      },
      amenities: [
        'Ocean View',
        'Private Pool',
        'Hot Tub',
        'Wifi',
        'Air Conditioning',
        'Free Parking',
        'Kitchen',
        'Outdoor Grill',
        'Smart TV',
        'Washer',
        'Dryer',
        'Gym',
        'Fireplace',
        'Essentials',
        'Hangers',
        'Hair Dryer',
        'Iron',
        'Beachfront Access',
        'Patio',
        'BBQ Grill',
        'Laptop-friendly workspace',
      ],
      price: {
        $numberDecimal: '500.00',
      },
      security_deposit: {
        $numberDecimal: '1000.00',
      },
      cleaning_fee: {
        $numberDecimal: '150.00',
      },
      extra_people: {
        $numberDecimal: '25.00',
      },
      guests_included: {
        $numberDecimal: '8',
      },
      images: {
        thumbnail_url: '',
        medium_url: '',
        picture_url: 'https://example.com/sunset_beach_villa.jpg',
        xl_picture_url: '',
      },
      host: {
        host_id: '12345678',
        host_url: 'https://www.airbnb.com/users/show/12345678',
        host_name: 'Emma & James',
        host_location: 'Miami Beach, Florida, USA',
        host_about:
          "We're a couple who loves sharing our beautiful home with guests. We're here to make your stay unforgettable.",
        host_response_time: 'within a few hours',
        host_thumbnail_url: 'https://example.com/host_thumbnail.jpg',
        host_picture_url: 'https://example.com/host_picture.jpg',
        host_neighbourhood: 'Miami Beach',
        host_response_rate: {
          $numberInt: '95',
        },
        host_is_superhost: true,
        host_has_profile_pic: true,
        host_identity_verified: true,
        host_listings_count: {
          $numberInt: '2',
        },
        host_total_listings_count: {
          $numberInt: '2',
        },
        host_verifications: ['email', 'phone', 'reviews', 'government_id'],
      },
      address: {
        street: '123 Ocean Drive',
        suburb: 'Miami Beach',
        government_area: 'Miami-Dade County',
        market: 'Miami',
        country: 'United States',
        country_code: 'US',
        location: {
          type: 'Point',
          coordinates: [
            {
              $numberDouble: '-80.120',
            },
            {
              $numberDouble: '25.790',
            },
          ],
          is_location_exact: true,
        },
      },
      availability: {
        availability_30: {
          $numberInt: '20',
        },
        availability_60: {
          $numberInt: '40',
        },
        availability_90: {
          $numberInt: '60',
        },
        availability_365: {
          $numberInt: '200',
        },
      },
      review_scores: {
        review_scores_accuracy: {
          $numberInt: '10',
        },
        review_scores_cleanliness: {
          $numberInt: '10',
        },
        review_scores_checkin: {
          $numberInt: '9',
        },
        review_scores_communication: {
          $numberInt: '10',
        },
        review_scores_location: {
          $numberInt: '10',
        },
        review_scores_value: {
          $numberInt: '9',
        },
        review_scores_rating: {
          $numberInt: '98',
        },
      },
      reviews: [
        {
          _id: '987654321',
          date: new Date(2023, 0, 1),
          listing_id: '98765432',
          reviewer_id: '56789012',
          reviewer_name: 'Sophie',
          comments:
            'This villa exceeded our expectations. The views are stunning!',
        },
        {
          _id: '987654322',
          date: new Date(2023, 4, 21),
          listing_id: '98765432',
          reviewer_id: '67890123',
          reviewer_name: 'David',
          comments: "A perfect getaway. We'll definitely be back!",
        },
        {
          _id: '987654323',
          date: new Date(2023, 10, 16),
          listing_id: '98765432',
          reviewer_id: '78901234',
          reviewer_name: 'Anna',
          comments:
            'The hosts were incredibly welcoming. The villa is a paradise!',
        },
      ],
    },
  ],
};
