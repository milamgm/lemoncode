﻿using EventRegistrationApi.Domain.Entities.Exceptions;


namespace EventRegistrationApi.Domain.Entities
{
    public abstract class Entity
    {

        private List<string> _validationErrors = new List<string>();

        public void Validate()
        {
            if (!_validationErrors.Any())
            {
                return;
            }

            var ex = new InvalidEntityStateException(_validationErrors);
            _validationErrors.Clear();
            throw ex;
        }

        protected abstract void EnsureStateIsValid();

        protected void AddValidationError(string errorMessage) => _validationErrors.Add(errorMessage);
    }

}
