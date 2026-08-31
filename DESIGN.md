# UI/UX Design Standards

This document defines the unified design system for our secure payment portal application. It ensures consistency across all user interfaces and provides clear guidelines for developers and designers.

---

## Table of Contents

1. [Color System](#color-system)
2. [Typography](#typography)
3. [Layout & Spacing](#layout--spacing)
4. [Components](#components)
5. [Interactions & Animations](#interactions--animations)
6. [Loading States](#loading-states)
7. [Notifications & Feedback](#notifications--feedback)
8. [Mobile-First Approach](#mobile-first-approach)
9. [Accessibility](#accessibility)
10. [Best Practices](#best-practices)

---

## Color System

### Primary Colors

```css
--bs-primary: #0658A3;          /* Deep Blue - Main Brand Color */
--bs-primary-rgb: 6, 88, 163;

--bs-secondary: #64748B;        /* Gray - Secondary Elements */
--bs-secondary-rgb: 100, 116, 139;
```

### Semantic Colors

| Type | Color Code | Usage |
|------|-----------|-------|
| Success | `#10B981` | Confirmation, successful operations |
| Danger | `#EF4444` | Errors, destructive actions |
| Warning | `#E6B800` / `#F7C91C` | Alerts, caution messages |
| Info | `#3167eb` | Informational content |
| Light | `#f8f9fa` | Backgrounds, subtle elements |
| Dark | `#212529` | Text, primary content |

### Button Colors

**Solid Buttons:**
- Primary: `#0658A3` (hover: `#054a8a`)
- Success: `#10B981` (hover: `#0da271`)
- Danger: `#EF4444` (hover: `#e03131`)
- Warning: `#F7C91C` (hover: `#e6b800`)
- Secondary: `#64748B` (hover: `#56657a`)
- Info: `#3167eb` (hover: `#2a5bd5`)

**Outline Buttons:** Use outline variants for secondary actions to maintain visual hierarchy.

---

## Typography

### Font Family

```css
font-family: "Roboto", sans-serif, system-ui, -apple-system;
```

### Font Sizes

| Element | Size | Notes |
|---------|------|-------|
| Base Body | 14px (desktop), 12px (mobile) | Default text size |
| Small Screens | 14px | Adjusted for mobile |
| Large Screens | 16px | Enhanced readability |
| H1-H6 | Following Bootstrap scale | Page headings |
| Navbar Title | 18px | Fixed header title |
| Back Button | 1.3rem | Navigation icons |

### Text Colors

- Primary text: `#212529`
- Secondary text: `#6c757d`, `#64748B` (muted)
- Link text: `#0366d6`
- Alert texts follow semantic color scheme

---

## Layout & Spacing

### Container Structure

**Main Container:**
```css
.container {
    max-width: 500px;
    margin: 20px auto;
    padding: 15px;
}

.width-phone {
    max-width: 480px;
    margin-left: auto;
    margin-right: auto;
    padding-left: 15px;
    padding-right: 15px;
}
```

**Key Principles:**
- Mobile-first design (max-width: 480px for main content)
- Centered layout for focused user experience
- Consistent 15px horizontal padding
- Sticky footer with 60px bottom margin

### Spacing Scale

Use Bootstrap spacing utilities (m-*, p-*, gap-*) for:
- Margin/padding: 0.25rem, 0.5rem, 1rem, 1.5rem, 2rem
- Gaps between flex items: 0.5rem to 2rem

### Grid System

- Bootstrap 5 default grid (12 columns)
- Mobile-first breakpoints: sm, md, lg, xl
- Flexible containers using flexbox utilities

---

## Components

### Navigation Bar

```html
<nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top">
```

**Features:**
- Sticky positioning (`position-sticky fixed-top`)
- Auto-hide on scroll down
- Show/hide back button via `ViewBag.ShowNavbarButton`
- Home button on right side
- Page title centered (`BarTitle` or `Title`)
- Shadow: `shadow-sm`

**Scroll Behavior:**
```javascript
// Hide when scrolling down, show when scrolling up
// Header height detection for accurate behavior
```

### Cards & Containers

- White background with subtle shadows
- Rounded corners: `border-radius: 0.375rem`
- Padding: `1rem` to `1.5rem`
- Border: None unless specified

### Form Elements

**Input Validation:**
```css
.is-valid { border-color: #10B981 !important; }
.is-invalid { border-color: #EF4444 !important; }
.valid-feedback { color: #10B981; }
.invalid-feedback { color: #EF4444; }
```

**Focus States:**
- Outline removed (cleaner look)
- Border color changes to semantic colors
- Smooth transitions

### Tables & Datatables

- DataTables jQuery plugin integration
- Responsive design support
- jQueryUI styling compatibility
- Column sorting, filtering, pagination enabled

### Modals

**Custom Modal (_ModalCustom.cshtml):**
- Centered layout
- Close button on top-right
- Customizable content area
- Z-index: 1050+

**Detail Modal (_ModalDetail.cshtml):**
- Larger width for details view
- Scrollable content if needed

### Alerts

**Alert Types:**
```html
<div class="alert alert-{type}" role="alert">
```

- Primary: `#d1e3f5` background, `#0658A3` text
- Success: `#d1f0e3` background, `#10B981` text
- Danger: `#fdd9d9` background, `#EF4444` text
- Warning: `#fdf3d4` background, `#E6B800` text
- Info: `#d6e3fb` background, `#3167eb` text

### Badges

```css
.badge.bg-{type} /* Self-contained colored badges */
```

Usage indicators, status labels, categories

### Progress Bars

```css
.progress-bar { background-color: #0658A3 !important; }
```

Follow semantic colors based on context

---

## Interactions & Animations

### Button Interactions

**Hover State:**
```css
.btn:hover:not(:active) {
    transform: translateY(-1px);
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}
```

**Active/Click State:**
```css
.btn:active {
    transform: translateY(-3px) !important;
    box-shadow: 0 8px 16px rgba(0, 0, 0, 0.15) !important;
}
```

**Transition Duration:** 0.2s ease

**Classes:** Apply `.button-animation` to buttons needing these effects

### Icon Animations

- Chevron/arrow icons for navigation
- House/home icon for homepage return
- Font Awesome & Bootstrap Icons integrated

### Transitions

**Smooth Transitions:**
- All interactive elements: `transition: 0.2s ease`
- Color changes: `transition: background-color 0.2s, color 0.2s`
- Transform animations: `transition: transform 0.3s ease`

---

## Loading States

### Global Loading Overlay

**Implementation:** `_GlobalLoading.cshtml`

**Features:**
- Dual-ring spinner animation
- Primary color accent (`#0658A3`)
- Custom loading message ("Memulat...", or dynamic)
- Z-index: 9999
- Semi-transparent white overlay

**Auto-Trigger Scenarios:**
1. Form submits (with validation check)
2. Internal link clicks (excluding downloads, external links)
3. Manual calls via `showGlobalLoading()` function

**Smart Behaviors:**
- Skip for `_blank` target links
- Skip for download actions (file exports)
- Skip if form validation fails
- Auto-hide after page load
- Delay 1800ms for better UX

**Animation Keyframes:**
```css
@keyframes spinRing {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}
@keyframes spinRingReverse {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(-360deg); }
}
```

---

## Notifications & Feedback

### Toast Notifications

**Implementation:** `_Toast.cshtml`

**API:**
```javascript
showToast(message, type, duration)
```

**Parameters:**
- `message`: String (required)
- `type`: 'success' \| 'warning' \| 'error' \| 'info' \| 'primary'
- `duration`: Number in ms (default: 3000)

**Toast Configurations:**

| Type | Background | Icon |
|------|-----------|------|
| Success | `#4CAF50` | Check Circle |
| Warning | `#FF9800` | Exclamation Triangle |
| Error | `#F44336` | Times Circle |
| Info | `#2196F3` | Info Circle |
| Primary | `#169CFD` | Bell |

**Design Characteristics:**
- Pill-shaped (rounded: 30px)
- Fixed position at bottom-center
- Auto-dismiss with fade-out
- Slide-in/slide-out animations
- Maximum 85% viewport width
- No duplicate toasts allowed

**Example Usage:**
```javascript
showToast("Pembayaran berhasil!", "success");
showToast("Kode disalin!", "info", 2500);
showToast("Saldo tidak cukup", "warning");
showToast("Gagal terhubung", "error");
```

### Alert Messages from Server

**Controller Integration:**
```csharp
TempData["alertMessage"] = "Success message";
TempData["alertStatus"] = "success"; // or error, warning, info
ViewData["disabledAlert"] = ""; // skip alert display
```

**Auto-display on Page Load:** Handled in `_Layout.cshtml`

---

## Mobile-First Approach

### Design Philosophy

**Target Device:**
- Primary focus: Mobile phones (320px - 480px)
- Tablet support: Up to 768px
- Desktop: Up to 500px max-content width

### Responsive Breakpoints

```css
/* Mobile (< 768px) */
html { font-size: 14px; }

/* Tablet & Desktop (≥ 768px) */
@media (min-width: 768px) {
    html { font-size: 16px; }
}
```

### Touch Optimization

- Touch-friendly button sizes (minimum 44px)
- Adequate spacing between interactive elements
- No hover-only interactions
- Tap highlight removal (`-webkit-tap-highlight-color: transparent`)

### Viewport Configuration

```html
<meta name="viewport" content="width=device-width, initial-scale=1">
```

Ensure proper scaling on all devices

---

## Accessibility

### WCAG Compliance

**Color Contrast:**
- All text meets AAA level contrast ratios
- Semantic colors tested against backgrounds
- No color-only information delivery

### Keyboard Navigation

- Full keyboard accessibility maintained
- Tab order logical and intuitive
- Focus states clearly visible
- Escape key closes modals

### Screen Reader Support

- ARIA labels where necessary
- Semantic HTML structure
- Alt text for images
- Meaningful heading hierarchy

### Motion Preferences

- Respects `prefers-reduced-motion` preference
- Animations are non-disruptive
- Loading indicators always useful, not decorative

---

## Best Practices

### Implementation Guidelines

**1. Follow Established Patterns**
- Always use the shared layout (`_Layout.cshtml`)
- Leverage pre-built components before creating new ones
- Maintain consistency with existing UI patterns

**2. Component Reusability**
- Create partial views for common elements
- Use Tag Helpers for cleaner markup
- Minimize inline styles

**3. Performance Optimization**
- Preload critical CSS resources
- Defer non-critical JavaScript
- Lazy-load images where appropriate
- Optimize asset delivery

**4. Security Considerations**
- Sanitize all user inputs
- Implement CSRF protection
- XSS prevention measures
- Secure data transmission

**5. Testing Requirements**
- Cross-browser testing (Chrome, Safari, Firefox, Edge)
- Mobile device testing (iOS, Android)
- Responsive breakpoints verification
- Accessibility audit regularly

### File Organization

```
wwwroot/
├── css/
│   ├── custom-theme.css  /* Primary customization */
│   └── site.css          /* General site styles */
├── js/
│   └── site.js           /* Shared JavaScript */
└── lib/                  /* Third-party libraries */
    ├── bootstrap/
    ├── jquery/
    ├── moment/
    └── ...

Views/
└── Shared/
    ├── _Layout.cshtml
    ├── _GlobalLoading.cshtml
    ├── _Toast.cshtml
    ├── _Modal*.cshtml
    └── _AlertModal.cshtml
```

### Naming Conventions

**CSS Classes:**
- Bootstrap prefixed: `btn-*`, `bg-*`, `text-*`
- Custom classes: lowercase with kebab-case (`button-animation`)
- Avoid global conflicts with namespace prefixes

**JavaScript Functions:**
- Global functions: camelCase (`showGlobalLoading`)
- Event handlers: descriptive names (`onFormSubmit`)
- Avoid polluting global namespace

**Partial Views:**
- Prefix with underscore: `_ComponentName.cshtml`
- Descriptive naming for context clarity

### Dependencies

**Core Framework:**
- ASP.NET Core MVC
- Bootstrap 5.3.8

**CDN Libraries:**
- jQuery 3.7.1
- Font Awesome 6.4.2
- Bootstrap Icons 1.11.3
- DataTables 1.13.6 + Responsive 2.5.0
- Moment.js 2.29.4 (with Indonesian locale)
- Alpine.js 3.x (for reactive components)
- JsBarcode 3.11.6 (for barcode generation)

### Version Management

Track library versions in `_Layout.cshtml` preload sections. Update dependencies quarterly or as security vulnerabilities emerge.

---

## Quick Reference

### Adding New Page

1. Copy existing view pattern
2. Set `ViewData["Title"]`
3. Configure `ViewBag.ShowNavbar` if needed
4. Implement validation in controller
5. Add success/error alerts via TempData

### Common Tasks

**Show Success Message:**
```csharp
TempData["alertMessage"] = "Operation successful!";
TempData["alertStatus"] = "success";
return RedirectToAction();
```

**Open Modal:**
```html
<button type="button" data-bs-toggle="modal" data-bs-target="#myModal">
    Open Modal
</button>
```

**Prevent Loading on Download:**
```html
<form action="/download" download>
<!-- Or add attribute -->
<a href="/file.pdf" download>Download</a>
```

---

## Maintenance & Updates

### Review Schedule

- **Monthly:** UI consistency audit
- **Quarterly:** Dependency updates
- **Bi-annually:** Comprehensive accessibility review
- **As-needed:** Pattern updates based on user feedback

### Contributing Changes

When proposing design changes:
1. Document the change rationale
2. Create prototype/mockup
3. Test across browsers/devices
4. Update this document accordingly
5. Get team approval

### Changelog Tracking

Document significant UI/UX changes in [`CHANGELOG.md`](CHANGELOG.md)

---

## Contact & Resources

**Design System Owner:** [Your Team]  
**Documentation Location:** `/DESIGN.md`  
**Component Library:** See `Views/Shared/` partial views  

For questions or contributions, refer to the main project repository documentation.

---

*Last Updated: 2024*  
*Version: 1.0*
