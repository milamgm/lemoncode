import { ObjectId } from 'mongodb';
import * as model from '#dals/index.js';
import * as apiModel from './listing.api-model.js';

export interface newReview extends apiModel.Review {
  listing_id: string;
}
export interface NewListingDetail extends Omit<apiModel.Listing, 'reviews'> {}

export const mapListingFromModelToApi = (
  listing: model.Listing
): apiModel.Listing => ({
  id: listing._id.toHexString(),
  name: listing.name,
  description: listing.description,
  bedrooms: listing.bedrooms,
  beds: listing.bedrooms,
  bathrooms: listing.bathrooms,
  images: listing.images,
  address: listing.address,
  reviews: listing.reviews.slice(-5),
});

export const mapListingListFromModelToApi = (
  listingList: model.Listing[]
): apiModel.Listing[] => listingList.map(mapListingFromModelToApi);

export const mapReviewFromApiToModel = (
  newReview: newReview
): model.Review | undefined => {
  if ('reviewer_name' in newReview && 'comments' in newReview) {
    const mappedReview = {
      _id: new ObjectId().toHexString(),
      date: new Date(),
      listing_id: newReview.listing_id,
      reviewer_id: new ObjectId().toHexString(),
      reviewer_name: newReview.reviewer_name,
      comments: newReview.comments,
    };
    return mappedReview;
  }
  return undefined;
};
