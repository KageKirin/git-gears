# git-gears

Git and git-host helper CLI tool.

Git Gears tries to bridge the gap between
a local git repository and remote git hosting services
by bringing service functionality straight to
the command line.

## Tech

git-gears is written in C# (.NET Core 3.x)
and (ulteriorly) compiled down to a native executable.

So far, git-gears uses:

- [CommandLineParser](https://github.com/commandlineparser/commandline)
- [libgit2sharp](https://github.com/libgit2/libgit2sharp) for Git integration
- [GraphQL.Client](https://github.com/graphql-dotnet/graphql-client) for GraphQL service interfacing
- [Flurl](https://flurl.dev) for REST service interfacing
- [Newtonsoft Json.NET](https://www.newtonsoft.com/json) for JSON parsing

### GraphQL and REST

Since both [GitHub](https://developer.github.com/v4/) and
[GitLab](https://docs.gitlab.com/ee/api/graphql/index.html)
expose a GraphQL interface,
git-gears uses the latter, instead of multiplying the dependencies on
hosting service specific libraries.

However, at the time of writing this,
not all functionality exposed via the respective GraphQL APIs
seems to be correctly implemented.
To bridge this gap, git-gears falls back on the REST API.

In the long run, this will also allow git-gears to interface
with other git hosting services that expose only a REST API.

## Name

git-gears is built and named after my personal proof-of-concept
Python script [git-cogs](https://github.com/KageKirin/git-cog.py),
but makes its pronounciation easier for non-native english speakers.
(I.e. not sound like male genitalia).  
The image is still that about dented wheels interacting
in a smooth mechanical system.

## Status

- git integration with libgit2 works, config can be read.
- GitHub proof-of-concept GraphQL connection works
- GitLab proof-of-concept GraphQL connection works
- GitHub `get-` and `list-` actions work, but only on the enterprise instance I use for testing.
- GitLab `get-` and `list-` actions except `pullrequests` work, but slightly different from their GitHub counterparts.

## Planned features

- GitHub support
- GitLab support
- atm, support for other hosting services is not planned. I take pull requests (e.g. for BitBucket).
- pull requests:
  - `git gears create-pullrequest`
  - `git gears close-pullrequest`
  - `git gears get-pullrequest`
  - `git gears list-pullrequests`
  - `git gears comment-pullrequest`
  - `git gears merge-pullrequest`
- issues:
  - `git gears create-issue`
  - `git gears close-issue`
  - `git gears get-issue`
  - `git gears list-issues`
  - `git gears comment-issue`
- gists:
  - `git gears create-gist`
  - `git gears remove-gist`
  - `git gears get-gist`
  - `git gears list-gists`
  - `git gears comment-gist`
- repos:
  - `git gears create-repo`
  - `git gears delete-repo`
  - `git gears get-repo`
  - `git gears list-repos`
  - `git gears fork-repo`

## Configuration

git-gears requires a few settings to be added to your git-config,
and allows to have different settings per project.
(The configuration is read in order from local -> global -> system).

- Section `[gears "my.host"]`: `my.host` corresponds to your git service hostname, e.g. github.com.
- token: this is your private access token generated by the service.
- api: the API type to use, either 'github' or 'gitlab' (atm)
- url: the service's GraphQL endpoint URL.
- rest: the service's REST endpoint root URL.

In general, this looks like that:

```ini
[gears "my.host"]
token = <your access token>
api = <github|gitlab>
url = https://my.host/api/graphql
rest = https://my.host/api
```

And a more concrete use-case are the following settings:

```ini
[gears "github.com"]
token = <your github access token>
api = github
url = https://api.github.com/graphql
rest = https://api.github.com
[gears "github.enterprise.org"]
token = <your github enterprise access token>
api = github
url = https://github.enterprise.org/api/graphql
rest = https://github.enterprise.org/api
[gears "gitlab.com"]
token = <your gitlab access token>
api = gitlab
url = https://gitlab.com/api/graphql
rest = https://gitlab.com/api/v4
```
