import { ListingRepository } from './listing.repository.js';
import { Listing, Review } from '../listing.model.js';
import { db } from '../../airbnb.mock-data.js';

const paginatedListingList = (
  listingList: Listing[],
  page: number,
  pageSize: number
): Listing[] => {
  let paginatedListingList = [...listingList];
  if (page && pageSize) {
    const startIndex = (page - 1) * pageSize;
    const endIndex = Math.min(
      startIndex + pageSize,
      paginatedListingList.length
    );
    paginatedListingList = paginatedListingList.slice(startIndex, endIndex);
  }

  return paginatedListingList;
};

export const mockRepository: ListingRepository = {
  getListingList: async (page?: number, pageSize?: number) =>
    paginatedListingList(db.listingsAndReviews, page, pageSize),
  getListing: async (id: string) =>
    db.listingsAndReviews.find((b) => b._id.toHexString() === id),
  saveReview: async (id: string, review: Review) => {
    db.listingsAndReviews = db.listingsAndReviews.map((b) =>
      b._id.toHexString() === id ? { ...b, reviews: [...b.reviews, review] } : b
    );
    return review;
  },
  saveListingDetail: async (id: string, listingDetail: Partial<Listing>) => {
    db.listingsAndReviews = db.listingsAndReviews.map((b) =>
      b._id.toHexString() === id ? { ...b, ...listingDetail } : b
    );
    return listingDetail;
  },
};
