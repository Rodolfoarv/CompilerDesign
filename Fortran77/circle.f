      program circle
      real r, area
      parameter (pi = 3.14159)

!     This program reads a real number r and prints
!     the area of the circle with radius r.

      write (*, *) 'Give radius r:'
      read  (*, *) r
      area = pi * r * r
      write (*, *) 'Area =', area

      stop
      end
