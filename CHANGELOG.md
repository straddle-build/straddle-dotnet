# Changelog

## [1.0.4](https://github.com/straddle-build/straddle-dotnet/compare/v1.0.0...v1.0.4) (2026-09-13)


### ⚠ BREAKING CHANGES

* **api:** 16 breaking changes to the SDK surface.
    - Response content type of `bridge.createBankAccountPaykey` changed from `text/plain` to `application/json`.
    - `400` error response of `bridge.createBankAccountPaykey` changed from `error_response` to `error_response`.
    - Response content type of `customers.create` changed from `text/plain` to `application/json`.
    - `400` error response of `customers.create` changed from `error_response` to `error_response`.
    - Response content type of `charges.create` changed from `text/plain` to `application/json`.
    - `400` error response of `charges.create` changed from `error_response` to `error_response`.
    - Response content type of `payouts.create` changed from `text/plain` to `application/json`.
    - `400` error response of `payouts.create` changed from `error_response` to `error_response`.
    - Property `payout.created_at` is now required.
    - Property `payout.created_at` type changed from `string<date-time> | null` to `string<date-time>`.
    - Property `payout.updated_at` is now required.
    - Property `payout.updated_at` type changed from `string<date-time> | null` to `string<date-time>`.
    - Property `unmasked_payout.created_at` is now required.
    - Property `unmasked_payout.created_at` type changed from `string<date-time> | null` to `string<date-time>`.
    - Property `unmasked_payout.updated_at` is now required.
    - Property `unmasked_payout.updated_at` type changed from `string<date-time> | null` to `string<date-time>`.
* **api:** 4 breaking changes to the SDK surface.
    - Property `embed_error_response.data` type changed from `unknown | null` to `unknown`.
    - Schema `customer_address` shape changed.
    - Schema `unmasked_compliance_profile` shape changed.
    - Schema `compliance_profile` shape changed.

### Features

* **api:** update property embed_error_response.data (+3 more changes) ([05596e3](https://github.com/straddle-build/straddle-dotnet/commit/05596e379e282ac44d6d4ebc483b7a8e003fbea1))
* **api:** update SDK surface (17 changes) ([35d8752](https://github.com/straddle-build/straddle-dotnet/commit/35d87521180deeb3536b1061e7f7654cf0334806))


### Chores

* release 1.0.3 ([2758547](https://github.com/straddle-build/straddle-dotnet/commit/275854789428ed18d9129ba6618e417907a8dcf1))
* release 1.0.3 ([a77e324](https://github.com/straddle-build/straddle-dotnet/commit/a77e3243ce275bc0234b324ba56875697b3a906b))
* release 1.0.4 ([d5b5f2a](https://github.com/straddle-build/straddle-dotnet/commit/d5b5f2ab397c9e52ed520ea61c5960c05cb9599f))
* release 1.0.4 ([25b03e0](https://github.com/straddle-build/straddle-dotnet/commit/25b03e094fed9ac55cd98f51cc2b2f6d685597ec))

## [1.0.0](https://github.com/straddle-build/straddle-dotnet/compare/v0.1.0...v1.0.0) (2026-09-03)


### Features

* **api:** initial SDK generation ([ccbcc3b](https://github.com/straddle-build/straddle-dotnet/commit/ccbcc3bde4d7c4646aff1db73ce51e4c28ca6689))


### Chores

* **api:** update generated SDK content ([40587fa](https://github.com/straddle-build/straddle-dotnet/commit/40587fa64edaa37b03c43a2a55e2c48274418914))
* **api:** update generated SDK content ([886ec71](https://github.com/straddle-build/straddle-dotnet/commit/886ec719167a9afea35eca16996ec9863b0eee64))
* release 1.0.0 ([aee65be](https://github.com/straddle-build/straddle-dotnet/commit/aee65be2485ed63da65690898fe8a92c23518cfb))
* release 1.0.0 ([06177b3](https://github.com/straddle-build/straddle-dotnet/commit/06177b318addfdab0248e7b358d024a4d23c970d))
