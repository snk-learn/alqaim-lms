﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AlQaim.Lms.SharedKernel;

public abstract class HasDomainEventsBase
{
  private readonly List<DomainEventBase> _domainEvents = new();

  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
  internal void ClearDomainEvents() => _domainEvents.Clear();
}
