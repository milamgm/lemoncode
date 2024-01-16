import { Listing, Review } from '../listing.model.js';

export interface ListingRepository {
  getListingList: (page?: number, pageSize?: number) => Promise<Listing[]>;
  getListing: (id: string) => Promise<Listing>;
  saveReview: (id: string, review: Review) => Promise<Review>;
  saveListingDetail: (id: string, listingDetail: Listing) => Promise<Partial<Listing>>;
}
