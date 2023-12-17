import { mapReviewFromApiToModel, newReview } from './listing.mappers.js';

describe('pods/listing/listing.mappers spec', () => {
  it('should return undefined when provided with a review object that does not match the expected model', () => {
    const wrongReview: any = {
      reviewer: 'Sophie',
      comment: 'Nice place',
    };
    const mappedResult = mapReviewFromApiToModel(wrongReview);
    expect(mappedResult).toBeUndefined();
  });
  it('showld return mapped review when petition matchs the expected model', () => {
    const rightReview: newReview = {
      listing_id: 'ejhrfkjsd',
      reviewer_name: 'Sophie',
      comments: 'Nice place',
    };
    const mappedResult = mapReviewFromApiToModel(rightReview);
    expect(mappedResult).not.toBeUndefined();
  });
});
