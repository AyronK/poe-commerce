# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## 0.1.0 - 2019-12-12
### Added
- Application starts with an overlay window with a button "Trade" in the bottom right corner of the screen
- Clicking the "Trade" button toggle trade window
- Added a single item search (bulk mode will be featured in the upcoming releases)
- Added the following filters to the trade window:
   - Item name/type/text
   - League
   - Online status
   - Type Filters (category, rarity)
   - Weapon Filters (damage, dps, crit etc.)
   - Armour Filter (armour, evasion, energy shield etc.)
   - Sockets Filters (colours, links etc.)
   - Requirements Filters (level, attributes etc.)
   - Map Filters (rarity, quantity, tier etc.)
   - Miscellaneous Filters (quality, gem level, corrupted, shaper etc.)
   - Trade Filters (price, seller, sale type)
   - Stat Filters (modifier, echants, pseudo etc.)
- Added item rendering
   - Image
   - Sockets
   - Links
- Added metadata rendering
   - Name
   - Type
   - Properties
   - Modifiers
   - Notes
   - Descriptions
   - and much more...
- Added listing rendering
   - Seller
   - Online status
   - Indexed timestamp
   - Price
- Added an instant in-game whisper button with marking as sent and with a redo option
- Added asynchronous result rendering (user sees first batch instantly and more items are loaded in the background)
- Added a clear filters button
- Filters can be now shown or hidden
- All static data options such are binded from Path of Exile API and will be ready for 3.9. The exceptions are for instance new influence type which will not show up in the filters
- Added UI errors logging - they will show up in %AppData%/The Wraeclast/PoE Commerce directory

## 0.1.0-alpha - 2019-11-16
### Added
- Desktop launcher with window management
- Logging to AppData directory with self cleaning log archive
