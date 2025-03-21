# Partas.Solid.UI

[//]: # (<div align="center">)

[![Scc Count Badge](https://sloc.xyz/github/shayanhabibi/Partas.Solid.UI/?category=code&badge-bg-color=9100FF)](https://github.com/shayanhabibi/Partas.Solid.UI/)
[![Scc Count Badge](https://sloc.xyz/github/shayanhabibi/Partas.Solid.UI/?category=comments&badge-bg-color=5E00B5)](https://github.com/shayanhabibi/Partas.Solid/)
[![Scc Count Badge](https://sloc.xyz/github/shayanhabibi/Partas.Solid.UI/?category=cocomo&badge-bg-color=3B0086)](https://github.com/shayanhabibi/Partas.Solid/)

[//]: # (</div>)

Port of [Solid-ui](https://solid-ui.com/) in Partas.Solid, Oxpecker style.

## Progress - Implemented & Tested

![img.png](img.png)

> Build the playground with `npm run start`

### Visualisations
- [x] Bar List
- [x] Charts
- [x] Delta Bar
- [x] Progress
- [x] Progress Circle

### UI
- [x] Accordion
- [x] Alert
- [x] Alert Dialog
- [ ]Aspect Ratio
- [x] Avatar
- [x] Badge
- [x] Badge Delta
- [x] Breadcrumb
- [x] Button
- [x] Callout
- [x] Card
-  Carousel
- [x] Checkbox
- [x] Collapsible
- [x] Combobox
- [x] Command
- [x] Context Menu
- [x] Data Table
- [x] Date Picker
- [x] Dialog
- [x] Drawer
- [x] Dropdown Menu
- [x] Hovercard
- [x] Label
- [x] Menubar
- [x] Navigation menu
- [x] Number Field
- [x] OtpField
- [x] Pagination
- [x] Popover
- [x] Radio Group
- [x] Resizeable
- [x] Select
- [x] Separator
- [x] Sheet
- [x] Sidebar
- [x] Skeleton
- [x] Slider
- [x] Sonner
- [x] Switch
- [x] Table
- [x] Tabs
- [x] Text Field
- [x] Timeline
-  ~~Toast~~ *Unnecessary with sonner*
- [x] Toggle
- [x] Toggle Group
- [x] Tooltip

### Layout
- [x] Flex
- [x] Grid


# Pain Points

Mostly to do with overloads, render props and funcs, etc. Will be attended to after functioning implementation of all components.

## Int Arrays

Libraries like ApexCharts need standard arrays rather than typed arrays. Since fable compiles, by default, int arrays into typed arrays on JS, we have to pass the `--typedArrays false` flag or unbox/box the ints so they are compiled as objs instead.