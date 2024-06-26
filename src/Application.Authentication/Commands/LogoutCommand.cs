﻿using Application.Authentication.Abstractions.CQRS;

namespace Application.Authentication.Commands;
public sealed record LogoutCommand(string Token) : ICommand;