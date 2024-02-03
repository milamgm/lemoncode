import { ObjectId } from 'mongodb';
export const mapListingFromModelToApi = (listing) => ({
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
export const mapListingListFromModelToApi = (listingList) => listingList.map(mapListingFromModelToApi);
export const mapReviewFromApiToModel = (newReview) => {
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
