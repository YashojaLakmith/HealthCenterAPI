using Domain.ValueObjects;

namespace EventContacts.Contracts;
public sealed record AdminCreatedEvent(EmailAddress AdminEmailAddress);
