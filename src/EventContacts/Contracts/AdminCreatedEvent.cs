using Domain.ValueObjects;

namespace EventContacts.Contracts;
internal sealed record AdminCreatedEvent(EmailAddress AdminEmailAddress);
